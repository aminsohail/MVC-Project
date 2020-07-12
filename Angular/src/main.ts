import 'hammerjs';
import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { environment } from './environments/environment';
import { HospitalManagementModule } from './app/HospitalManagement.Main.module';

if (environment.production) {
  enableProdMode();
}

platformBrowserDynamic().bootstrapModule(HospitalManagementModule)
  .catch(err => console.log(err));
