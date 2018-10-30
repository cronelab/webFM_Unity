# Code for WebFM's Unity / WebGL display


![alt text](/WebFM.PNG)

- Generate a brain mesh
  - Using Freesurfer/[img_pipe](https://github.com/ChangLabUcsf/img_pipe) generate an .obj/.mtl file
    - patient=img_pipe.freeCoG(subj='subj', hem='hem')
    - patient.plot_brain()
    - Save As ...
  - Import .obj/.mtl file into Blender and convert to .blend/.fbx
  - Import .blend/.fbx into Unity
  - Build scene for WebGL

- Import build files into [WebFM](https://github.com/cronelab/webfm)
 - webfm/public/webFM_Display
