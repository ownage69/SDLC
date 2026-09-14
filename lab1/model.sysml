package SuperheroCalculator {
    part def SuperheroModel {
        attribute data;
        attribute level;
        attribute score;
        port notify; // уведомления (событие StateChanged)
    }
    
    part def MainForm {
        port listen;
        port userAction;
    }
    
    part def InputForm;
    
    part def SuperheroController {
        port handle;
    }
    
    part def System {
        part appModel : SuperheroModel;
        part mainView : MainForm;
        part appDialog : InputForm;
        part appController : SuperheroController;

        connect mainView.userAction to appController.handle;
        connect appModel.notify to mainView.listen;
    }
}