#!/bin/bash
dotnet restore

# Build Library and Example
for path in src/*/project.json; do
    dirname="$(dirname "${path}")"
    dotnet build ${dirname} -c Release
done

# Run Unit Tests
dotnet build test/UnitTest/project.json -f netcoreapp1.0 -c Release
dotnet run -p test/UnitTest/project.json -f netcoreapp1.0  -c Release
