<h1 align="center">Cube Rotation 👋</h1>
<p>
  <img alt="Version" src="https://img.shields.io/badge/version-V0.2-blue.svg?cacheSeconds=2592000" />
  <a href="doc/UserPDF/html/index.html" target="_blank">
    <img alt="Documentation" src="https://img.shields.io/badge/documentation-yes-brightgreen.svg" />
  </a>
  <a href="todo" target="_blank">
    <img alt="License: MIT" src="https://img.shields.io/badge/License-MIT-yellow.svg" />
  </a>
</p>

>   Implements Cube Rotation, lighting and back culling without using any frame but MVP matrix

## What is this Project?

It is a simple implementation of Cube rotation Windows Form APP using MVP matrix in .NET Core (C#).
Due to the time, the coding structure is not beautiful and needs to be strengthened later. 
As an assignment, it shows my understanding of how matrix works in games.

This project is fully based on Math class slides, two great Blog Articles and one video from Youtube.


### 1- Unity : From noob to expert Ch.1 3D Math
Link: https://www.bookstack.cn/read/shenjun-unity/98.md

### 2- 3D shapes - knowledge about matrix

Link:https://www.jianshu.com/p/ab71816f7d82

### 3- Coding Challenge #112: 3D Rendering with Rotation and Projection
Link:https://www.youtube.com/watch?v=p4Iz0XJY-Qk

## Notes:

:bulb: There are 2 different AI in the project:

#### :low_brightness: 1- Rotate Angle:
The rotate angle is hardcoded at **Timer1_Tick** method in **MyFrom.cs**, it rotate around all axis(default settings).
```
private void Timer1_Tick(object sender, EventArgs e)
        {
            //Angle per sec
            a += 1;
            double angle = a / 360.0 * Math.PI;
            ...
        }   
```  

#### :low_brightness: 2- How to Operate:  
:bulb: You could choose the rotate axis by clicking the axis buttons below, for example:
<br>
<br>
Rotate around ***All*** axis: <br>
none button chosen<br>
<br>
Rotate around ***X*** axis: <br>
choose Y and Z button<br>
<br>
Rotate around ***Y*** axis: <br>
choose X and Z button<br>
<br>
Rotate around ***Z*** axis: <br>
choose X and Y button<br>
<br>

:bulb: Drag the slider bar on the top could scale the cube


I hope those could be useful !.

Ruikang Xu


### ✨ [Download](https://monsterlady.github.io/ZombieNPC/)

## Comments

All comments are described above each relevant code blocks


## Environments

```sh
IDE: IntellJ Rider
Development Enviroment: .NET Core V3.1.402
Software operating environment： Windowns 10 64 bits
```

## Author

👤 **Ruikang Xu**

* Github: [@Bestitz](https://github.com/monsterlady)



## 📝 License

Copyright © 2020 [Ruikang Xu](https://github.com/Bestitz).<br />
