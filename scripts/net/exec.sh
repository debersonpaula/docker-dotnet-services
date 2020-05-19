#!/bin/bash

echo "Removendo rede webnet..."
docker network rm "xpwebnet"

echo "Construindo rede webnet..."
docker network create -d bridge xpwebnet