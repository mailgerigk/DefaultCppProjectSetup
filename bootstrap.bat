git submodule update --init --recursive

@echo off
pushd %~dp0
call %~dp0\sharpmake\git_clone_common.bat
call %~dp0\sharpmake\git_update_common.bat
call %~dp0\sharpmake\build_all.bat
popd