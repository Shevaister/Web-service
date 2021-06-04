from django.contrib.auth.forms import UserCreationForm
from django.urls import reverse_lazy
from django.views import generic
from django.contrib.auth.models import User
from django.http import HttpResponseRedirect
from django.shortcuts import render
from django.shortcuts import render, redirect
from django.contrib.auth import authenticate, login
from django.contrib.auth.forms import AuthenticationForm
from django.contrib.auth import logout

def signup_view(request):
    return render(request, 'registration/sign-in.html')

def signup(request):
    user = User.objects.create_user(request.POST.get('fullname'), request.POST.get('username'), request.POST.get('password'))
    user.save()
    return HttpResponseRedirect('/accounts/signup')

def signin(request):
    if request.user.is_authenticated:
        return HttpResponseRedirect('/')
    if request.method == 'POST':
        username = request.POST['username']
        password = request.POST['password']
        user = authenticate(request, username=username, password=password)
        if user is not None:
            login(request, user)
            return HttpResponseRedirect('/')
        else:
            form = AuthenticationForm(request.POST)
            return HttpResponseRedirect('/accounts/signup')
    else:
        form = AuthenticationForm()
        return render(request, 'signin.html', {'form': form})

def logout_view(request):
    logout(request)
    return HttpResponseRedirect('/')
