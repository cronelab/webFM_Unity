%See how Bioimage and Freesurfer electrode coordinate systems match up

Coords_Bioimage = []
Coords_Freesurfer = [
    load('Data/Freesurfer/RSI.mat')
    load('Data/Freesurfer/RPH.mat')
    load('Data/Freesurfer/RF.mat')
    load('Data/Freesurfer/RAH.mat')
    load('Data/Freesurfer/RA.mat')
    load('Data/Freesurfer/LSI.mat')
    load('Data/Freesurfer/LPH.mat')
    load('Data/Freesurfer/LII.mat')
    load('Data/Freesurfer/LF.mat')
    load('Data/Freesurfer/LBT.mat')
    load('Data/Freesurfer/LAH.mat')
    load('Data/Freesurfer/LA.mat')
]
%%
plot3(Coords_Freesurfer(1).elecmatrix(:,1), Coords_Freesurfer(1).elecmatrix(:,2),Coords_Freesurfer(1).elecmatrix(:,3),'xb')
hold on
plot3(Coords_Freesurfer(2).elecmatrix(:,1), Coords_Freesurfer(2).elecmatrix(:,2),Coords_Freesurfer(2).elecmatrix(:,3),'xg')
plot3(Coords_Freesurfer(3).elecmatrix(:,1), Coords_Freesurfer(3).elecmatrix(:,2),Coords_Freesurfer(3).elecmatrix(:,3),'xr')
%%
plot3(Coords_Bioimage(:,1),Coords_Bioimage(:,2),Coords_Bioimage(:,3),'x')
hold on
plot3(Coords_Freesurfer(:,1),Coords_Freesurfer(:,2),Coords_Freesurfer(:,3),'o')