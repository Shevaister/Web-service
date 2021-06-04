from django.urls import path
from .views import *
urlpatterns = [
    #path('home', admin.site.urls),
    path('', homepage ,name = 'hom'),
    path('upload', file_upload, name = 'upload'),
    path('delete/<int:id>', delete, name = 'delete')
    #path('gayshit' ,file_upload, name = 'xdd'),
    #path('smt', htt, name = 'xddd'),
    #path('', ... , name = 'delete'),
    #path('', ..., name = '')
]