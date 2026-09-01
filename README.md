<div align="center">

# AnotoAR

An augmented reality project built with Unity and Vuforia Engine.

[![Unity](https://img.shields.io/badge/Unity-6000.3.10f1-000000?logo=unity&logoColor=white)](https://unity.com/)
[![Vuforia](https://img.shields.io/badge/Vuforia-11.4.4-5CB531)](https://developer.vuforia.com/)
[![URP](https://img.shields.io/badge/URP-17.3.0-4C8BF5)](https://unity.com/srp/universal-render-pipeline)
[![GitHub Pages](https://img.shields.io/badge/Live_Demo-Open-5865F2)](https://guapi03.github.io/AnotoAR/)

</div>

## About

AnotoAR is an augmented reality application developed using Unity and Vuforia Engine.  
The project explores interactive AR content that can be viewed through a supported mobile device.

## Project Demo

<p align="center">
  <a href="https://guapi03.github.io/AnotoAR/">
    <img
      src="https://img.youtube.com/vi/1MdkWUGiNzo/maxresdefault.jpg"
      alt="AnotoAR project demo"
      width="720"
    >
  </a>
</p>

<p align="center">
  <a href="https://guapi03.github.io/AnotoAR/">
    <strong>▶️ Play the embedded video demo</strong>
  </a>
  &nbsp;•&nbsp;
  <a href="https://www.youtube.com/shorts/1MdkWUGiNzo">
    Watch on YouTube
  </a>
</p>

> GitHub README files cannot play embedded YouTube videos directly.  
> Use the GitHub Pages link above to play the video without uploading the MP4 file to this repository.

## Features

- Augmented reality experience
- Image-target tracking with Vuforia Engine
- Interactive 3D content
- Unity Input System support
- Universal Render Pipeline
- Mobile-device build support
- Embedded video demonstration through GitHub Pages

## Technologies

| Technology | Version |
|---|---:|
| Unity | `6000.3.10f1` |
| Vuforia Engine | `11.4.4` |
| Universal Render Pipeline | `17.3.0` |
| Unity Input System | `1.18.0` |
| AI Navigation | `2.0.10` |
| Visual Scripting | `1.9.9` |

## Requirements

Before opening the project, install:

- [Unity Hub](https://unity.com/download)
- Unity Editor `6000.3.10f1`
- The required Android or iOS build-support module
- Git
- A supported AR-capable mobile device
- A Vuforia license configuration, if required by the selected scene

Using a different Unity version may cause package upgrades or compatibility warnings.

## Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/Guapi03/AnotoAR.git
cd AnotoAR
```

### 2. Open the project

1. Open Unity Hub.
2. Click **Add → Add project from disk**.
3. Select the cloned `AnotoAR` directory.
4. Open it using Unity `6000.3.10f1`.
5. Wait for Unity Package Manager to restore all dependencies.

### 3. Configure Vuforia

1. Open the scene that contains the AR camera.
2. Check that Vuforia Engine is enabled.
3. Add your Vuforia license key if the project requires one.
4. Confirm that the required image-target database is enabled.

### 4. Run the project

1. Connect a supported mobile device.
2. Open **File → Build Profiles** in Unity.
3. Select the required mobile platform.
4. Switch to that platform if necessary.
5. Add the required scene to the build.
6. Click **Build and Run**.

Camera permission must be enabled on the mobile device for AR tracking to work.

## Project Structure

```text
AnotoAR/
├── Assets/                 # Scenes, scripts, models and AR assets
├── Packages/               # Unity package configuration
├── ProjectSettings/        # Unity project settings
├── QCAR/                   # Vuforia/QCAR-related files
├── docs/
│   └── index.html          # GitHub Pages video website
├── .gitignore
├── README.md
└── InputSystem_Actions.inputactions
```

## GitHub Pages

The project demonstration website is available at:

**https://guapi03.github.io/AnotoAR/**

The website source is located at:

```text
docs/index.html
```

GitHub Pages should be configured with:

```text
Source: Deploy from a branch
Branch: main
Folder: /docs
```

After updating `docs/index.html`, commit and push the changes. GitHub Pages will deploy the new version automatically.

## Troubleshooting

### Unity opens the project with package errors

Make sure the project is opened using Unity `6000.3.10f1`, then allow Unity Package Manager to restore the required packages.

### Vuforia camera does not start

Check that:

- Camera permission is enabled.
- Vuforia Engine is installed.
- The Vuforia license key is valid.
- The correct AR scene is included in the build.
- The mobile device supports the required AR functionality.

### Image target is not detected

Check that:

- The correct target database is enabled.
- The printed or displayed target has sufficient lighting.
- The target is clearly visible to the camera.
- The target image is not heavily blurred or obstructed.

### GitHub Pages shows a 404 page

Confirm that:

- `docs/index.html` exists on the `main` branch.
- GitHub Pages is configured to publish from `main` and `/docs`.
- The latest Pages deployment completed successfully under the **Actions** tab.

## Repository

- Source code: [github.com/Guapi03/AnotoAR](https://github.com/Guapi03/AnotoAR)
- Embedded demo: [guapi03.github.io/AnotoAR](https://guapi03.github.io/AnotoAR/)
- YouTube video: [AnotoAR Project Demo](https://www.youtube.com/shorts/1MdkWUGiNzo)

## Author

Created by [Guapi03](https://github.com/Guapi03).

## License

This repository currently does not include an open-source license.

Unless a license is added, the project remains under the copyright of its author and may not automatically be copied, modified, or redistributed.
