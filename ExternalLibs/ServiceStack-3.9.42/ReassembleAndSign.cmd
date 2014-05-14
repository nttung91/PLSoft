REM Signing an Unsigned Assembly
REM http://buffered.io/posts/net-fu-signing-an-unsigned-assembly-without-delay-signing

ilasm /dll /key=Common-Libs.snk ServiceStack.Interfaces.il
ilasm /dll /key=Common-Libs.snk ServiceStack.Text.il

sn -Tp ServiceStack.Interfaces.dll
REM Add publickeytoken to all assemblies
REM .publickeytoken = (2C F1 04 5B A1 6B 89 91 )