CS_FILES = $(shell find Takarakuji/ -type f -name *.cs)
CS_TEST_FILES = $(shell find TakarakujiTest/ -type f -name *.cs)

Takarakuji/bin/Debug/Takarakuji.dll: $(CS_FILES)
		xbuild Takarakuji/Takarakuji.csproj > /dev/null
TakarakujiTest/bin/Debug/TakarakujiTest.dll: $(CS_TEST_FILES)
		xbuild TakarakujiTest/TakarakujiTest.csproj > /dev/null
all: Takarakuji/bin/Debug/Takarakuji.dll TakarakujiTest/bin/Debug/TakarakujiTest.dll
test: all
		mono packages/NUnit.Runners.2.6.4/tools/nunit-console-x86.exe TakarakujiTest/bin/Debug/TakarakujiTest.dll
release:
	git subtree push --prefix Takarakuji origin release/unity/plain

.PHONY: test
