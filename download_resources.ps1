$latestInfo = Invoke-WebRequest -Uri https://github.com/yamachu/VCLib/releases/latest -MaximumRedirection 0  -ErrorAction SilentlyContinue
$Location = $latestInfo.Headers.Location
$Location -match ".*/tag/(?<tagName>.*?)$"
$latestVersion = $Matches.tagName
"$latestVersion"
$baseUrl = "https://github.com/yamachu/VCLib/releases/download/$latestVersion"

Invoke-WebRequest "$baseUrl/libvclib_double.dylib" -OutFile resources\osx\libvclib_double.dylib
Invoke-WebRequest "$baseUrl/libvclib_float.dylib" -OutFile resources\osx\libvclib_float.dylib
Invoke-WebRequest "$baseUrl/libvclib_double.so" -OutFile resources\linux\libvclib_double.so
Invoke-WebRequest "$baseUrl/libvclib_float.so" -OutFile resources\linux\libvclib_float.so
Invoke-WebRequest "$baseUrl/x86_vclib_double.dll" -OutFile resources\win-x86\vclib_double.dll
Invoke-WebRequest "$baseUrl/x64_vclib_double.dll" -OutFile resources\win-x64\vclib_double.dll
Invoke-WebRequest "$baseUrl/x86_vclib_float.dll" -OutFile resources\win-x86\vclib_float.dll
Invoke-WebRequest "$baseUrl/x64_vclib_float.dll" -OutFile resources\win-x64\vclib_float.dll
