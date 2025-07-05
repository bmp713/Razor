
// Toggle dark mode class 
window.toggleDarkClass = () => {
    document.body.classList.toggle('dark');

    // List of all classes with .dark defined in app.css
    const darkClasses = [
        'update',
        'users',
        'top-row',
        'list-group-item',
        'btn-primary',
        'input'
    ];
    darkClasses.forEach(cls => {
        document.querySelectorAll('.' + cls).forEach(el => {
            el.classList.toggle('dark');
        });
    });
    return document.body.classList.contains('dark');
};

