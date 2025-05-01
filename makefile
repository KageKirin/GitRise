GITHUB_TOKEN?=${GITHUB_TOKEN}
GITHUB_USER?=${GITHUB_USER}

f format:
	@fd . -td --max-depth 1 --search-path . | xargs -P 8 -I _ sh -c "echo _; cd _; fd '\.cs$$' -tf -X dotnet csharpier {}; fd '\.cs$$' -tf -X dos2unix -q -r {};"
	@fd csproj$$ -X dos2unix -q -r {}

r restore:
	dotnet restore

b build:
	dotnet build

p pack:
	dotnet pack

publish:
	dotnet push
