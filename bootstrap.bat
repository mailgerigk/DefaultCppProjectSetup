git submodule update --init --recursive

@echo off
pushd %~dp0
call %~dp0\sharpmake\build_all.bat
popd