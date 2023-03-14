


We can use the following section the import external linux repositories:

ENV DEBIAN_FRONTEND=noninteractive

RUN apt-get update \
    && apt-get install -y --no-install-recommends \
        # # ca-certificates \
        curl \
        # jq \
        # git \
        iputils-ping \
        # net-tools \
        # krb5-user \
        # # libcurl4 \
        # # libicu70 \
        libunwind8 \
        netbase \
        # netcat \
        # # less \
        # libopenblas-base \
        zip \
        unzip \
        apt-transport-https \
        software-properties-common \
        lsb-release \
        # # openssl \
        gnupg \
        gnupg-agent \
        gnupg2 \
    && apt-get autoremove -y \
    && apt-get autoclean -y \
    && rm -rf /var/lib/apt/lists/*

WORKDIR /opt/work-dir

COPY container-setup/files/* ./
COPY container-setup/etc/* /etc/

# Inserting additional package sources and installing azure, docker, kubernetes, sql and odbc packages:
# SRC: https://askubuntu.com/a/1307181, https://docs.docker.com/engine/install/ubuntu/#install-using-the-repository
RUN update-ca-certificates \
    && OS_DISTRO=$(lsb_release -is) \
    && OS_REPO=$(lsb_release -cs) \
    && OS_VERSION=$(lsb_release -rs) \
    && OS_ARCH=$(dpkg --print-architecture) \
    && echo "OS: ${OS_DISTRO} Version: ${OS_VERSION} Codename: ${OS_REPO} Architecture: ${OS_ARCH}" \
    && mkdir -m 0755 -p /etc/apt/keyrings \
    && apt-get update \
    && curl -sSL "https://packages.microsoft.com/config/ubuntu/${OS_VERSION}/"` \
        `"packages-microsoft-prod.deb" -o "/tmp/packages-microsoft-prod.deb" \
    && apt-get install -y --no-install-recommends \
        "/tmp/packages-microsoft-prod.deb" \
    && curl -sSL https://packages.microsoft.com/keys/microsoft.asc \
        | gpg --dearmor -o /etc/apt/keyrings/microsoft.asc.gpg \
    && echo "deb [arch=${OS_ARCH} signed-by=/etc/apt/keyrings/microsoft.asc.gpg] "` \
        `"https://packages.microsoft.com/repos/azure-cli/ ${OS_REPO} main" \
        | tee -a /etc/apt/sources.list.d/azure-cli.list \
    && curl -sSL https://download.docker.com/linux/ubuntu/gpg \
        | gpg --dearmor -o /etc/apt/keyrings/docker.gpg \
    && echo "deb [arch=${OS_ARCH} signed-by=/etc/apt/keyrings/docker.gpg] "` \
        `"https://download.docker.com/linux/ubuntu ${OS_REPO} stable" \
        | tee -a /etc/apt/sources.list.d/docker.list \
    && curl -sSL https://packages.cloud.google.com/apt/doc/apt-key.gpg \
        | gpg --dearmor -o /etc/apt/keyrings/kubernetes.gpg \
    && echo "deb [arch=${OS_ARCH} signed-by=/etc/apt/keyrings/kubernetes.gpg] "` \
        `"https://apt.kubernetes.io/ kubernetes-xenial main" \
        | tee -a /etc/apt/sources.list.d/kubernetes.list \
    && apt-get update \
    && ACCEPT_EULA=Y apt-get install -y --no-install-recommends \
        powershell \
        azure-cli \
        # docker-ce \
        # docker-ce-cli \
        # containerd.io \
        kubectl \
        msodbcsql17 \
        unixodbc \
        unixodbc-dev \
        mssql-tools \
    && apt-get autoremove -y \
    && apt-get autoclean -y \
    && rm -rf /var/lib/apt/lists/*
