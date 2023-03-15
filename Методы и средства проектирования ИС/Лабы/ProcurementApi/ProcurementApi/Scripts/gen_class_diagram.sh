#!/usr/bin/env bash

SCRIPT_DIR=$( cd -- "$( dirname -- "${BASH_SOURCE[0]}" )" &> /dev/null && pwd )

if ! dotnet tool list -g | grep -q 'plantumlclassdiagramgenerator'; then
   echo "You should install plantumlclassdiagramgenerator to generate a class diagram!"
   exit   
fi 

puml-gen $SCRIPT_DIR/../Core $SCRIPT_DIR/../UML/Model -dir -excludePaths DTOs -allInOne -ignore
puml-gen $SCRIPT_DIR/../Repositories $SCRIPT_DIR/../UML/Repositories -dir -allInOne -ignore
puml-gen $SCRIPT_DIR/../Services $SCRIPT_DIR/../UML/Services -dir -allInOne -ignore
puml-gen $SCRIPT_DIR/../Controllers $SCRIPT_DIR/../UML/Controllers -dir -allInOne -ignore