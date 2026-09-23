@echo off

REM ==== API ====
cd WebApiDotNet
docker build -t webpd411 .
docker tag webpd411:latest novakvova/webpd411:latest
docker push novakvova/webpd411:latest

echo DONE
pause
