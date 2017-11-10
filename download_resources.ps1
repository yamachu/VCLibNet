$latestInfo = Invoke-WebRequest -Uri https://github.com/yamachu/VCLib/releases/latest -MaximumRedirection 0  -ErrorAction SilentlyContinue
$Location = $latestInfo.Headers.Location
$Location -match ".*/tag/(?<tagName>.*?)$"
$latestVersion = $Matches.tagName
"$latestVersion"
$baseUrl = "https://github.com/yamachu/VCLib/releases/download/$latestVersion"

Invoke-WebRequest "$baseUrl/libvclib.dylib" -OutFile resources\osx\libvclib.dylib
Invoke-WebRequest "$baseUrl/libvclib.so" -OutFile resources\linux\libvclib.so
Invoke-WebRequest "$baseUrl/x86_vclib.dll" -OutFile resources\win-x86\vclib.dll
Invoke-WebRequest "$baseUrl/x64_vclib.dll" -OutFile resources\win-x64\vclib.dll