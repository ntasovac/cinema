import { Component, OnInit } from '@angular/core';
import { AbstractControl,
        FormBuilder, 
        FormGroup, 
        FormControl, 
        Validators
 } from '@angular/forms';
import { LoginInfo } from 'src/app/core/models/loginInfo';
import { AuthService } from 'src/app/core/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit  {
  form: FormGroup = new FormGroup({
    email: new FormControl(''),
    password: new FormControl(''),
  });

  submitted = false;


  constructor(private formBuilder: FormBuilder, private authService: AuthService) {}
  ngOnInit(): void {
    this.form = this.formBuilder.group(
      {
        email: ['', Validators.required],
        password: [
          '',
          [
            Validators.required,
            Validators.minLength(5),
          ],
        ],
      }
    );
  }

  onSubmit(): void { 
    this.submitted = true;

    if (this.form.invalid) {
      return;
    }

    const loginUser: LoginInfo = {
      email: this.form.value.email,
      password: this.form.value.password
    };

    this.authService.login(loginUser).subscribe(
      (response) => {
        console.log('Login successful:', response);
        // Ovde možeš da sačuvaš token ili uradiš neku logiku
      },
      (error) => {
        console.error('Login failed:', error);
        // Ovde možeš prikazati korisniku poruku o grešci
      }
    );

    console.log("pritisnem dugme");
  }

  get f(): { [key: string]: AbstractControl } {
    return this.form.controls;
  }
  onReset(): void {
    this.submitted = false;
    this.form.reset();
  }

}

/*
    public int Id { get; set; }
    public string Email {  get; set; } // jel name treba id ili su useri jedinstveni preko email-a
    public string PasswordHash { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public DateOnly BirthDate { get; set; }
    public UserType Type { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiryTime { get; set; }
*/