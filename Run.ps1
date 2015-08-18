$msbuild = "C:\WINDOWS\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe"
$nunit = "C:\Program Files\NUnit-2.6.4\bin"

$curDir = $MyInvocation.MyCommand.Definition | split-path -parent

$NUnitHTMLReportGenerator = $curDir + "\Tests\Tools\NUnitHTMLReportGenerator\NUnitHTMLReportGenerator.exe"
$testsDll = $curDir + "\Tests\bin\Debug\Tests.dll"
$testsBin = $curDir + "\Tests\bin"
$wrappersBin = $curDir + "\Wrappers\bin"
$testsProject = $curDir + "\Tests\Tests.csproj"
$wrappersProject = $curDir + "\Wrappers\Wrappers.csproj"
$resultsDir = $curDir + "\Results"
$resultsXml = $resultsDir + "\results.xml"
$resultsHtml = $resultsDir + "\results.html"

New-Item -Path $resultsDir -ItemType "directory"

Remove-Item $testsBin -Recurse
Remove-Item $wrappersBin -Recurse
Remove-Item $resultsHtml -Recurse

& $msbuild $wrappersProject /t:Build /p:Configuration=Debug
& $msbuild $testsProject /t:Build /p:Configuration=Debug
& $nunit\nunit-console.exe /xml:$resultsXml $testsDll
& $NUnitHTMLReportGenerator $resultsXml $resultsHtml