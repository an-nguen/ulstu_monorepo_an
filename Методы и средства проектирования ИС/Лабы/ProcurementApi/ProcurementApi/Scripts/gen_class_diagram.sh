#!/usr/bin/env bash

SCRIPT_DIR=$(cd "$(dirname "${BASH_SOURCE[0]}")" &> /dev/null && pwd )
echo $SCRIPT_DIR
if ! dotnet tool list -g | grep -q 'plantumlclassdiagramgenerator'; then
   echo "You should install plantumlclassdiagramgenerator to generate a class diagram!"
   exit   
fi 

#puml-gen "$SCRIPT_DIR/../Core" "$SCRIPT_DIR/../UML/Model" -dir -excludePaths DTOs -ignore
#puml-gen "$SCRIPT_DIR/../Repositories" "$SCRIPT_DIR/../UML/Repositories" -dir -ignore
#puml-gen "$SCRIPT_DIR/../Services" "$SCRIPT_DIR/../UML/Services" -dir -ignore
#puml-gen "$SCRIPT_DIR/../Controllers" "$SCRIPT_DIR/../UML/Controllers" -dir -ignore
puml-gen "$SCRIPT_DIR/.." "$SCRIPT_DIR/../UML" -dir -excludePaths Config,Scripts,bin,obj,home -allInOne -ignore -public
