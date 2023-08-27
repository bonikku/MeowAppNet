import { Component } from '@angular/core'
import { HttpClient } from '@angular/common/http'

@Component({
  selector: 'app-test-error',
  templateUrl: './test-error.component.html',
  styleUrls: ['./test-error.component.css'],
})
export class TestErrorComponent {
  baseUrl = 'https://localhost:5001/api'
  validationErrors: string[] = []

  constructor(private http: HttpClient) {}

  get404Error() {
    this.http.get(`${this.baseUrl}/bug/not-found`).subscribe({
      next: (res) => console.log(res),
      error: (err) => console.log(err),
    })
  }

  get400Error() {
    this.http.get(`${this.baseUrl}/bug/bad-request`).subscribe({
      next: (res) => console.log(res),
      error: (err) => console.log(err),
    })
  }

  get500Error() {
    this.http.get(`${this.baseUrl}/bug/server-error`).subscribe({
      next: (res) => console.log(res),
      error: (err) => console.log(err),
    })
  }

  get401Error() {
    this.http.get(`${this.baseUrl}/bug/auth`).subscribe({
      next: (res) => console.log(res),
      error: (err) => console.log(err),
    })
  }

  get400ValidationError() {
    this.http.post(`${this.baseUrl}/account/register`, {}).subscribe({
      next: (res) => console.log(res),
      error: (err) => {
        console.log(err)
        this.validationErrors = err
      },
    })
  }
}
