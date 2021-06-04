from django.db import models

class complete_photos(models.Model):
    photo = models.ImageField(upload_to = 'complete_photos/')
    user_id = models.IntegerField()
    number_of_humans = models.IntegerField()