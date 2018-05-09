import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { EditorComponent } from './editor/editor.component';
import { MarkdownViewerComponent } from './markdown-viewer/markdown-viewer.component';
import { DirectoryComponent } from './directory/directory.component';

@NgModule({
  declarations: [
    AppComponent,
    EditorComponent,
    MarkdownViewerComponent,
    DirectoryComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
