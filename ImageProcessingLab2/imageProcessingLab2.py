import cv2 as cv
import sys
import numpy as np
from matplotlib import pyplot as plt

img1 = cv.imread('1.jpg')
img2 = cv.imread('2.jpg')
img3 = cv.imread('3.jpg')
img4 = cv.imread('4.jpg')
img5 = cv.imread('5.jpg')
img6 = cv.imread('6.jpg')
img7 = cv.imread('7.jpg')
img8 = cv.imread('8.jpg')
img9 = cv.imread('9.jpg')
img10 = cv.imread('10.jpg')
img11 = cv.imread('11.jpg')
img12 = cv.imread('12.jpg')

i = 211


def NonLocalMeans(img, n):
    b, g, r = cv.split(img)
    rgb_img = cv.merge([r, g, b])

    dst = cv.fastNlMeansDenoisingColored(img, None, 10, 10, 7, 21)
    b, g, r = cv.split(dst)  # g e t b , g , r
    rgb_dst = cv.merge([r, g, b])  # swi t c h i t t o rgb
    plt.subplot(n), plt.imshow(rgb_img)
    n += 1
    plt.subplot(n), plt.imshow(rgb_dst)
    plt.show()


NonLocalMeans(img1, i)
NonLocalMeans(img2, i)
NonLocalMeans(img3, i)
NonLocalMeans(img4, i)
NonLocalMeans(img5, i)
NonLocalMeans(img6, i)
NonLocalMeans(img7, i)
NonLocalMeans(img8, i)
NonLocalMeans(img9, i)
NonLocalMeans(img10, i)
NonLocalMeans(img11, i)
NonLocalMeans(img12, i)


def BilaterialFilter(img, n):
    b, g, r = cv.split(img)
    rgb_img = cv.merge([r, g, b])
    bilateral = cv.bilateralFilter(img, 40, 25, 75)
    plt.subplot(n), plt.imshow(rgb_img)
    n += 1
    plt.subplot(n), plt.imshow(bilateral)
    plt.show()


BilaterialFilter(img1, i)
BilaterialFilter(img2, i)
BilaterialFilter(img3, i)
BilaterialFilter(img4, i)
BilaterialFilter(img5, i)
BilaterialFilter(img6, i)
BilaterialFilter(img7, i)
BilaterialFilter(img8, i)
BilaterialFilter(img9, i)
BilaterialFilter(img10, i)
BilaterialFilter(img11, i)
BilaterialFilter(img12, i)


def CalcOfDamageAndNonDamage(image_name):
    image = cv.imread(image_name)
    kernel = cv.getStructuringElement(cv.MORPH_ELLIPSE, (7, 7))
    image_erode = cv.erode(image, kernel)
    hsv_img = cv.cvtСolor(image_erode, cv.COLOR_BGR2HSV)
    markers = np.zeros((image.shape[0], image.shape[1]), dtype="int32")
    markers[90: 140, 90: 140] = 255
    markers[236: 255, 0: 20] = 1
    markers[0: 20, 0: 20] = 1
    markers[0: 20, 236: 255] = 1
    markers[236: 255, 236: 255] = 1
    leafs_area_bgr = cv.watershed(image_erode, markers)
    healthy_part = cv.inRange(hsv_img, (36, 25, 25), (86, 255, 255))
    ill_part = leafs_area_bgr - healthy_part
    mask = np.zeros_like(image, np.uint8)
    mask[leafs_area_bgr > 1] = (255, 0, 255)
    mask[ill_part > 1] = (0, 0, 255)
    return mask
