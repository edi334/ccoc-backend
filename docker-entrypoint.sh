#!/bin/sh

set -e
groupadd --gid ${NETCORE_USER_UID} netcore && useradd --uid ${NETCORE_USER_UID} -g netcore netcore

mkdir -p ${PERSISTED_KEYS_DIRECTORY}
chmod -R u=rwX,g=rX,o= /app/persisted
chown -RL netcore:netcore /app/persisted

cd /app/bin
exec sudo -E -u netcore dotnet CCOCBackend.API.dll