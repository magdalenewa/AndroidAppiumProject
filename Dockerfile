FROM mcr.microsoft.com/windows/servercore:1803-amd64
COPY ["Tosca.exe", "C:/"]
RUN Tosca.exe /s /qn -Wait
COPY ["License.xml", "C:/ProgramData/TRICENTIS/Tosca Testsuite/7.0.0/License"]
COPY ["ToscaCIRemoteExecutionService.exe.config", "C:/Program Files (x86)/TRICENTIS/Tosca Testsuite/ToscaCommander/ToscaCI"]
COPY ["ToscaCIClient.exe.config", "C:/Program Files (x86)/TRICENTIS/Tosca Testsuite/ToscaCommander/ToscaCI/Client"]
COPY ["powershell.ps1", "C:/"]
CMD ["powershell", "C:/powershell.ps1"]
