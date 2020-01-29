.PHONY: test install

install:
	nuget restore CSharpHTTPClient/CSharpHTTPClient.sln
	nuget install NUnit.Runners -Version 2.6.4 -OutputDirectory testrunner

test: install
	xbuild /p:Configuration=Release CSharpHTTPClient/CSharpHTTPClient.sln
	mono ./testrunner/NUnit.Runners.2.6.4/tools/nunit-console.exe UnitTest/bin/Release/UnitTest.dll -domain:None
	nuget pack ./CSharpHTTPClient/CSharpHTTPClient.csproj -Properties Configuration=Release
	curl -s https://codecov.io/bash > .codecov
	chmod +x .codecov
	./.codecov
