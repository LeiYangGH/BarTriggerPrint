﻿function ZipFiles( $zipfilename, $sourcedir )
{
   Add-Type -Assembly System.IO.Compression.FileSystem
   $compressionLevel = [System.IO.Compression.CompressionLevel]::Optimal
   [System.IO.Compression.ZipFile]::CreateFromDirectory($sourcedir,$zipfilename)
}

function CreateDir($dir)
{
    If(!(test-path $dir))
    {
          New-Item -ItemType Directory -Force -Path $dir
    }
}

$BarDir = 'C:\G\BarTriggerPrint'
$MSBuildDir = 'C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin'
If (-not (Test-Path $MSBuildDir)){
	$MSBuildDir = 'E:\VS17\MSBuild\15.0\Bin'
}
cd $MSBuildDir
.\msbuild "$BarDir\src\BarTriggerPrint.csproj" /p:Configuration=Release /p:PlatformTarget=x86 /t:Rebuild

$dt = [DateTime]::Now.ToString("yyyyMMddHHmm") 
$makefromdir ="$BarDir\Releases"
CreateDir($makefromdir)
$debugdir = "$BarDir\src\bin\Release"
$exclude = @('*.pdb','*.xml','*vshost*','*.log','de','es','fr','hu','it','pt-BR','ro','ru','sv','zh-Hans')
Remove-Item "$makefromdir\*" -Recurse -Force
Copy-Item "$debugdir\*" $makefromdir -Recurse -Exclude $exclude -Force
Copy-Item "$BarDir\src\说明.txt" $makefromdir -Force


#cd 'C:\Program Files (x86)\NSIS'
#.\makensis.exe "$BarDir\BarCheck.nsi"
#$installout = "$BarDir\BarCheck_install.exe"
#$installzipdir = "$BarDir\BarCheck_install"
#CreateDir($installzipdir)
#Remove-Item "$installzipdir\*" -Force
#Copy-Item "$BarDir\说明.txt" $installzipdir -Force
#Copy-Item $installout $installzipdir  -Force

cd $BarDir

$zipfile = "$BarDir\\BarTriggerPrint_$dt.zip"
If (Test-Path $zipfile){
	Remove-Item $zipfile
}
ZipFiles  $zipfile $makefromdir 
#If (Test-Path $installout){
#	Remove-Item $installout -Force
#}
#Copy-Item $zipfile $installzipdir  -Force

#If (Test-Path $zipfile){
#	Remove-Item $zipfile -Force
#}
$zipfile

if ($error.Count > 0){
Read-Host
}

