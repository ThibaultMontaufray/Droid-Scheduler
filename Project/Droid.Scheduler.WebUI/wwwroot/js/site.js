function pagecalled(menu, option) {
    switch (menu) {
        case 'menu.french':
            window.location.href = (option == "create") ? "/Brain/BrainCreate" : ("/Brain/BrainView?lg=fr&word=" + option);
            break;
        case 'menu.english':
            window.location.href = "/Brain/BrainView?lg=en&word=" + option;
            break;
        case 'menu.dashboard':
            window.location.href = "/Server/Dashboard";
            break;
        case 'menu.scheduler':
            window.location.href = "/Server/Scheduler";
            break;
        default:
            console.log('Sorry, we are out of ' + menu + '.');
    }
    
}