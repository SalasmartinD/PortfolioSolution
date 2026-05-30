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
    document.addEventListener('mouseleave', function () {
        halo.style.opacity = 0;
    });

    // 3. Delegated listeners for hover states on interactive items
    document.addEventListener('mouseover', function (e) {
        if (e.target.closest('a, button, .btn, .glass-card, .contact-glass-card, [role="button"], input, textarea')) {
            halo.classList.add('cursor-hover');
        }
    });

    document.addEventListener('mouseout', function (e) {
        if (e.target.closest('a, button, .btn, .glass-card, .contact-glass-card, [role="button"], input, textarea')) {
            halo.classList.remove('cursor-hover');
        }
    });

    // 4. Función de animación (Se ejecuta en cada frame)
    function animate() {
        // Suavizar el movimiento (Lerp) para efecto de arrastre premium
        currentX += (targetX - currentX) * 0.08; 
        currentY += (targetY - currentY) * 0.08;

        // Aplicar la transformación de CSS
        halo.style.transform = `translate(${currentX}px, ${currentY}px) translate(-50%, -50%)`;
        
        requestAnimationFrame(animate);
    }
    
    // Iniciar la animación
    animate();
};

window.setupScrollSpy = function () {
    const sections = document.querySelectorAll('section[id]');
    const navLinks = document.querySelectorAll('.nav-link');
    if (sections.length === 0 || navLinks.length === 0) return;

    function spy() {
        let scrollY = window.pageYOffset || document.documentElement.scrollTop;
        
        // Find which section is currently in viewport
        sections.forEach(current => {
            const sectionHeight = current.offsetHeight;
            // Subtract offset to make active trigger slightly before section top hits center
            const sectionTop = current.offsetTop - 180;
            const sectionId = current.getAttribute('id');
            
            if (scrollY > sectionTop && scrollY <= sectionTop + sectionHeight) {
                navLinks.forEach(link => {
                    link.classList.remove('active');
                    if (link.getAttribute('href') === '#' + sectionId || link.getAttribute('href') === '/' + '#' + sectionId) {
                        link.classList.add('active');
                    }
                });
            }
        });
    }

    // Bind scroll listener
    window.addEventListener('scroll', spy);
    // Initialize once
    spy();
};