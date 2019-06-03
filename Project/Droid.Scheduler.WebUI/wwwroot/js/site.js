function pagecalled(menu, option) {
    switch (menu) {
        case 'menu.jobs':
            window.location.href = (option == "create") ? "/Jobs/Create" : ("/Jobs/Detail?name=" + option);
            break;
        case 'menu.dashboard':
            window.location.href = "/Dashboard";
            break;
        case 'menu.settings':
            window.location.href = "/Settings";
            break;
        case 'menu.scheduler':
            window.location.href = "/Scheduler";
            break;
        default:
            console.log('Sorry, we are out of ' + menu + '.');
    }
    
}