import { GLTFLoader } from "../lib/threeJS/GLTFLoader.js";

let renderBody = document.getElementsByTagName("main")[0];
renderBody = document.getElementById("logobogo");
let height = 80;

const scene = new THREE.Scene();

const camera = new THREE.PerspectiveCamera(75, height / height, 0.1, 1000);
camera.position.set(0, 0, 7);

let light = new THREE.HemisphereLight(0xFFFFFF, 0x000000, 2);
scene.add(light);

const renderer = new THREE.WebGLRenderer({ alpha: true });
renderer.setSize(height, height);

renderBody.appendChild(renderer.domElement)

let loader = new GLTFLoader();
let model;
loader.load("./StaticFiles/scene.gltf", gltf => {
    model = gltf.scene;
    scene.add(model);
    model.rotation.z = Math.PI / 4;
})

function animate() {
    requestAnimationFrame(animate);
    model.rotation.y += 0.01;
    model.position.y = Math.sin(model.rotation.y)
    renderer.render(scene, camera);
}

animate();