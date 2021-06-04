from django.shortcuts import render
from django.http import HttpResponseRedirect
import os
from django.conf import settings
from .models import complete_photos
from django.core.files.storage import default_storage
from .models import complete_photos 

def homepage(request):
    user = request.user
    if user.is_authenticated:
        photos = complete_photos.objects.filter(user_id = user.id)
        return render(request, 'client/home.html',{'photos': photos})
    else:
        return render(request, 'client/home.html')


def file_upload(request):
    file = request.FILES.get('cover')
    a = file.name
    a = a.split('.')
    current_user = request.user
    f = open('id.txt', 'r')
    f_id = f.read()
    f_id = int(f_id)
    f_id += 1
    save_path = os.path.join(settings.MEDIA_ROOT, 'raw_photos', "{}_{}.{}".format(f_id, current_user.id, a[1]))
    path = default_storage.save(save_path, request.FILES.get('cover'))
    f = open('id.txt', 'w')
    f.write(str(f_id))
    return HttpResponseRedirect('/')

def delete(request, id):
    photo = complete_photos.objects.get(id = id)
    if request.user.id == photo.user_id:
        photo.delete()
    return HttpResponseRedirect('/')




    