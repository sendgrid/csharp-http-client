.PHONY: clean install test release

clean:
	dotnet clean CSharpHTTPClient/CSharpHTTPClient.sln

install:
	@dotnet --version || (echo "Dotnet is not installed, please install Dotnet CLI"; exit 1);
	dotnet restore CSharpHTTPClient/CSharpHTTPClient.sln

test:
	dotnet build -c Release CSharpHTTPClient/CSharpHTTPClient.sln
	dotnet test -c Release CSharpHTTPClient/CSharpHTTPClient.sln
	curl -s https://codecov.io/bash > .codecov
	chmod +x .codecov
	./.codecov

release:
	dotnet pack -c Release CSharpHTTPClient/CSharpHTTPClient.sln