FROM mcr.microsoft.com/playwright/dotnet:v1.41.1-jammy

WORKDIR /app

COPY . .

CMD ["dotnet", "test", "--", "NUnit.NumberOfTestWorkers=1"]