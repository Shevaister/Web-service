from django.urls import path, include
from .views import *

urlpatterns = [
    #path('', include('django.contrib.auth.urls')),
    path('signup/', signup_view, name = 'signup'),
    path('signup/register', signup, name = 'signup_end'),
    path('signup/signin', signin , name = 'signin'),
    path('logout/', logout_view, name = 'logout'),
]