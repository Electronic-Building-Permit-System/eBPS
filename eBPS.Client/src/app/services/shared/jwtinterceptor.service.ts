import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { UserService } from '../account/user.service';

export const jwtInterceptor: HttpInterceptorFn = (req, next) => {
  const userService = inject(UserService); // Inject UserService
  const token = userService.getToken(); // Retrieve the token

  // Clone the request and add the Authorization header if the token exists
  const clonedReq = token
    ? req.clone({
        setHeaders: {
          Authorization: `Bearer ${token}`,
        },
      })
    : req;

  return next(clonedReq); // Pass the cloned or original request
};
