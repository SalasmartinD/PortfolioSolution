window.setupCursorHalo = function () {
    const halo = document.getElementById('cursor-halo');
    if (!halo) return;

    let targetX = 0;
    let targetY = 0;
    let currentX = 0;
    let currentY = 0;

    // 1. Capturar el movimiento del cursor
    document.addEventListener('mousemove', function (e) {
        targetX = e.clientX;
        targetY = e.clientY;
        
        // Mostrar el halo cuando el mouse se mueva
        halo.style.opacity = 1; 
    });
    
    // 2. Controlar la desaparición del halo
    document.addEventListener('mouseout', function () {
        halo.style.opacity = 0;
    });

    // 3. Función de animación (Se ejecuta en cada frame)
    function animate() {
        // Suavizar el movimiento: currentX se acerca lentamente a targetX
        currentX += (targetX - currentX) * 1; 
        currentY += (targetY - currentY) * 1;

        // Aplicar la transformación de CSS
        halo.style.transform = `translate(${currentX}px, ${currentY}px) translate(-50%, -50%)`;
        
        requestAnimationFrame(animate);
    }
    
    // Iniciar la animación
    animate();
};