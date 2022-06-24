
docker run -dit --rm -p 2222:2222 `
    -v I:/Develop:/code `
    -v /var/run/docker.sock:/var/run/docker.sock `
    scherlac/devserver:latest

# sudo docker run -dit --rm -p 139:139 -p 445:445 `
#     -v devdisk:/code `
#     dperson/samba `
#     -p `
#     -u "userX;UserX" `
#     -s "public;/code"
