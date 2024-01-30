# How to place prefabs in maps

| 1. Place an entity and set the class to "prefab". | 2. Add a new key named "prefabpath" and assign your path. | 3. Add a CustomMapInstance component and load the map like normal. |
|--------|--------|--------|
| ![image](https://github.com/badandbest/sbox-custom-map-entities/assets/91832803/1e7a8671-9030-47c7-bc59-cccbae9e8c64) | ![image](https://github.com/badandbest/sbox-custom-map-entities/assets/91832803/19222d77-9a15-46d8-8540-f7e807ad2b3c) ![image](https://github.com/badandbest/sbox-custom-map-entities/assets/91832803/92945379-ea25-49ae-9a52-c502989bc33a) | ![image](https://github.com/badandbest/sbox-custom-map-entities/assets/91832803/ba0f4880-6792-4a85-bb26-290f2bf77c15) |

![image](https://github.com/badandbest/sbox-custom-map-entities/assets/91832803/33b087d6-88b1-49ab-9c11-68d0d05974b4)
___

# Custom Entities

1. Set a class name. This is what we'll use to find it.
![image](https://github.com/badandbest/sbox-custom-map-entities/assets/91832803/bbb64d98-6692-45e8-86c9-2e263311fcad)

2. You can store variables using keys. All of this data will be compiled into the map.  
![image](https://github.com/badandbest/sbox-custom-map-entities/assets/91832803/db81f2a3-78b2-479c-971a-67e0b0f88d65)

4. In CustomMapLoader, add the class name and configure what it should do.
![image](https://github.com/badandbest/sbox-custom-map-entities/assets/91832803/68e0cb75-2dc0-4e62-92f3-e49e315e4747)

5. You can read your key values with hammerData.GetString( key name )
![image](https://github.com/badandbest/sbox-custom-map-entities/assets/91832803/30518e13-63e3-4533-b276-9042ab1bcb13)

Result:

![image](https://github.com/badandbest/sbox-custom-map-entities/assets/91832803/4e9fc375-6d69-4f7c-ac4f-f202795ceb7a)

I've included the examples in the repo. If you have any questions feel free to ask me on discord (badandbest).
