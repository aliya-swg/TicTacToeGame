FROM mcr.microsoft.com/dotnet/runtime:8.0-windowsservercore-ltsc2019
WORKDIR C:\\app
COPY ./publish .
ENTRYPOINT ["TicTacToeGame.exe"]