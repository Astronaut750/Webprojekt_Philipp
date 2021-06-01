import * as THREE from 'https://threejsfundamentals.org/threejs/resources/threejs/r127/build/three.module.js';
import { GLTFLoader } from "../lib/threeJS/GLTFLoader.js";

function main() {
    const canvas = document.querySelector('#c');
    const renderer = new THREE.WebGLRenderer({ canvas, alpha: true });

    const fov = 75;
    const aspect = 2;  // the canvas default
    const near = 0.1;
    const far = 100;
    const camera = new THREE.PerspectiveCamera(fov, aspect, near, far);

    const skyboxScene = new THREE.Scene();
    const mainScene = new THREE.Scene();

    // light
    {
        let light = new THREE.HemisphereLight(0xFFFFFF, 0x000000, 2);
        mainScene.add(light);
    }

    let boardModel;
    {
        const gltfLoader = new GLTFLoader();
        gltfLoader.load("./StaticFiles/scene.gltf", gltf => {
            boardModel = gltf.scene;
            mainScene.add(boardModel);
            boardModel.rotation.z = Math.PI / 4;
        })
    }

    // camera.rotation.x = - Math.PI / 2;    // +up -down        pitch
    // camera.rotation.y = Math.PI / 4;    // +left -right     yaw
    // camera.rotation.z = Math.PI / 4;    //                  roll

    let skybox;
    {
        const size = 20;
        const geometry = new THREE.BoxGeometry(size, size, size);

        const textureLoader = new THREE.TextureLoader();

        const materials = [
            new THREE.MeshBasicMaterial({ map: textureLoader.load("../img/skybox/corona_rt.png") }), // right
            new THREE.MeshBasicMaterial({ map: textureLoader.load("../img/skybox/corona_lf.png") }), // left
            new THREE.MeshBasicMaterial({ map: textureLoader.load("../img/skybox/corona_up.png") }), // up     => had to rotate 90° counter-clockwise
            new THREE.MeshBasicMaterial({ map: textureLoader.load("../img/skybox/corona_dn.png") }), // down   => had to rotate 90° clockwise
            new THREE.MeshBasicMaterial({ map: textureLoader.load("../img/skybox/corona_bk.png") }), // back
            new THREE.MeshBasicMaterial({ map: textureLoader.load("../img/skybox/corona_ft.png") }), // front
        ];

        materials.forEach(m => {
            m.side = THREE.BackSide;
        })

        skybox = new THREE.Mesh(geometry, materials);
        skyboxScene.add(skybox);
    }
    
    function resizeRendererToDisplaySize(renderer) {
        const canvas = renderer.domElement;
        const width = canvas.clientWidth;
        const height = canvas.clientHeight;
        const needResize = canvas.width !== width || canvas.height !== height;
        if (needResize) {
            renderer.setSize(width, height * 1.5, false);
        }
        return needResize;
    }

    let increment = 0.0;

    let xCycle = false;
    let yCycle = false;
    let zCycle = false;

    $("#toggleX").click(() => {
        xCycle = !xCycle;
        $("#toggleX").toggleClass("btn-danger");
        $("#toggleX").toggleClass("btn-dark");
    });

    $("#toggleY").click(() => {
        yCycle = !yCycle;
        $("#toggleY").toggleClass("btn-success");
        $("#toggleY").toggleClass("btn-dark");
    });

    $("#toggleZ").click(() => {
        zCycle = !zCycle;
        $("#toggleZ").toggleClass("btn-primary");
        $("#toggleZ").toggleClass("btn-dark");
    });

    function render() {
        increment += 0.0075;

        if (resizeRendererToDisplaySize(renderer)) {
            const canvas = renderer.domElement;
            camera.aspect = canvas.clientWidth / canvas.clientHeight;
            camera.updateProjectionMatrix();
        }

        if (xCycle) camera.position.x = 5 * Math.sin(increment);
        else camera.position.x = 0;

        if (yCycle) camera.position.y = - 5 * Math.sin(increment);
        else camera.position.y = 0;

        if (zCycle) camera.position.z = 5 * Math.cos(increment);
        else camera.position.z = 7;

        skybox.position.x = camera.position.x;
        skybox.position.y = camera.position.y;
        skybox.position.z = camera.position.z;

        if (boardModel) {
            camera.lookAt(boardModel.position)
        }

        renderer.render(skyboxScene, camera);
        renderer.autoClear = false;
        renderer.render(mainScene, camera)

        requestAnimationFrame(render);
    }

    requestAnimationFrame(render);
}

main();