#!/bin/bash

CONFIG=$1

if [ $# -eq 0 ]
  then
    echo "Nenhum comando fornecido."
  else
    echo 'Executando aplicação =' $1
    cd ./scripts/$1
    ./exec.sh
fi