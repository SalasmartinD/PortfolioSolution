#!/bin/bash
echo "--- INICIANDO INSTALACION .NET ---"
curl -sSL https://dot.net/v1/dotnet-install.sh | bash /dev/stdin --channel 10.0 --install-dir .dotnet
export DOTNET_ROOT=$(pwd)/.dotnet
export PATH=$PATH:$DOTNET_ROOT

echo "--- PUBLICANDO PROYECTO ---"
dotnet publish Portfolio.Client/Portfolio.Client.csproj -c Release -o output

echo "--- BUSCANDO EL ARCHIVO PERDIDO ---"
# Esto nos dirá en los logs dónde está exactamente el archivo
find output -name "blazor.webassembly.js"