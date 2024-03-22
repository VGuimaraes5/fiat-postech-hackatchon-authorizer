dotnet restore ./Lambdas/AuthLambda
dotnet publish ./Lambdas/AuthLambda -c "Release" --framework "net6.0" /p:GenerateRuntimeConfigurationFiles=true -r linux-x64 --self-contained false
cd ./terraform
terraform apply
cd ..