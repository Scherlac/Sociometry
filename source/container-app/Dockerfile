FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0

EXPOSE 2222 80

RUN apt-get update && export DEBIAN_FRONTEND=noninteractive \
    && apt-get -y install --no-install-recommends \
        openssh-server \
    && rm -rf /var/lib/apt/lists/* \
    && ssh-keygen -A \
    && mkdir -p /var/run/sshd \
    && echo "root:Docker!" | chpasswd

WORKDIR /app
COPY --from=build-env /app/out .
COPY /scripts/data/sshd_config /etc/ssh/sshd_config
COPY --chmod=0755 /scripts/data/startup.sh ./

ENTRYPOINT ["bash", "/app/startup.sh"]