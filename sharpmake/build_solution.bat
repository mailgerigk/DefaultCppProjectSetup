@echo off
pushd %~dp0
%~dp0\vendor\Sharpmake\tmp\bin\debug\net5.0\Sharpmake.Application.exe /sources('src/Solutions/MainSolution.cs') /generateDebugSolution
popd