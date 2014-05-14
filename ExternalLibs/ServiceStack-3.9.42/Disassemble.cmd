REM Signing an Unsigned Assembly
REM http://buffered.io/posts/net-fu-signing-an-unsigned-assembly-without-delay-signing

ildasm /all /out=ServiceStack.Interfaces.il ServiceStack.Interfaces.dll
ildasm /all /out=ServiceStack.Common.il ServiceStack.Common.dll
ildasm /all /out=ServiceStack.il ServiceStack.dll
ildasm /all /out=ServiceStack.ServiceInterface.il ServiceStack.ServiceInterface.dll
ildasm /all /out=ServiceStack.Text.il ServiceStack.Text.dll
