#!/usr/bin/env bash
dotnet new console -o 1-new_project
dotnet restore
dotnet build 1-new_project
dotnet run
