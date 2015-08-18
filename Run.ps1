$msbuild = "C:\WINDOWS\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe"
$nunit = "C:\Program Files\NUnit-2.6.4\bin"

$NUnitHTMLReportGenerator = "Tests\Tools\NUnitHTMLReportGenerator\NUnitHTMLReportGenerator.exe"
$resultsXml = "Results\results.xml"
$resultsHtml = "Results\results.html"

Remove-Item Wrappers\bin -Recurse
Remove-Item Tests\bin -Recurse
Remove-Item $resultsHtml -Recurse

& $msbuild Wrappers\Wrappers.csproj /t:Build /p:Configuration=Debug
& $msbuild Tests\Tests.csproj /t:Build /p:Configuration=Debug
& $nunit\nunit-console.exe /xml:$resultsXml Tests\bin\Debug\Tests.dll
& $NUnitHTMLReportGenerator $resultsXml $resultsHtml