- Mobile-device build support

## Technology Stack

| Technology | Version |
| --- | ---: |
| Unity | `6000.3.10f1` |
| Vuforia Engine | `11.4.4` |
| Universal Render Pipeline | `17.3.0` |
| Unity Input System | `1.18.0` |
| AI Navigation | `2.0.10` |
| Visual Scripting | `1.9.9` |

## Requirements

- [Unity Hub](https://unity.com/download)
- Unity Editor `6000.3.10f1`
- Android or iOS build-support module for the target platform
- Git
- A supported AR-capable mobile device
- A valid Vuforia license configuration, if required by the selected scene

> Opening the project with a different Unity version may trigger package upgrades or compatibility warnings.

## Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/Guapi03/AnotoAR.git
cd AnotoAR
```

### 2. Open the project

1. Open Unity Hub.
2. Select **Add → Add project from disk**.
3. Choose the cloned `AnotoAR` directory.
4. Open it with Unity `6000.3.10f1`.
5. Wait for Unity Package Manager to restore the dependencies.

### 3. Configure Vuforia

1. Open the scene containing the AR camera.
2. Confirm that Vuforia Engine is enabled.
3. Add a Vuforia license key if the project requires one.
4. Make sure the required image-target database is enabled.

### 4. Build and run

1. Connect a supported mobile device.
2. Open **File → Build Profiles** in Unity.
3. Select and switch to the required mobile platform.
4. Add the AR scene to the build.
5. Select **Build and Run**.
6. Allow camera access when prompted on the device.

## Project Structure

```text
AnotoAR/
├── Assets/                          # Scenes, scripts, models, and AR assets
├── Packages/                        # Unity package configuration
├── ProjectSettings/                 # Unity project settings
├── QCAR/                            # Vuforia/QCAR-related files
├── InputSystem_Actions.inputactions # Input System actions
├── .gitignore
└── README.md
```

## Troubleshooting

### Package errors

Open the project with Unity `6000.3.10f1` and allow Unity Package Manager to finish restoring all dependencies.

### AR camera does not start

- Confirm that the device has granted camera permission.
- Check that Vuforia Engine is installed and enabled.
- Verify the Vuforia license configuration.
- Make sure the correct scene is included in the build.

### Image target is not detected

- Confirm that the correct target database is enabled.
- Use sufficient and even lighting.
- Keep the target clearly visible and in focus.
- Avoid covering, bending, or blurring the target image.

## Links

- [Repository](https://github.com/Guapi03/AnotoAR)
- [YouTube demo](https://www.youtube.com/shorts/1MdkWUGiNzo)

## Author

Created by [Guapi03](https://github.com/Guapi03).

## License

This repository does not currently include an open-source license. Unless a license is added, the project remains under the copyright of its author.
