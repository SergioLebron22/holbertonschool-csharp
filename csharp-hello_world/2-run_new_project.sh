#!/usr/bin/env bash
dotnet new console -o 2-new_project
dotnet restore
dotnet build 2-new_project
dotnet run 2-new_project
