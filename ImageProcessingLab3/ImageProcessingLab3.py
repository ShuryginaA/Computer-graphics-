import cv2 as cv
import numpy as np
from matplotlib import pyplot as plt
import glob


# Дискретное преобразвание Фурье
def showDFFT(img, fft, name):
    magnitude = np.abs(fft)
    plt.subplot(121), plt.imshow(img, 'Greys', vmin=0, vmax=255)
    plt.title('Input Image'), plt.xticks([]), plt.yticks([])

    s_min = magnitude.min()
    s_max = magnitude.max()
    if s_min == s_max:
        plt.subplot(122), plt.imshow(magnitude, 'Greys', vmin=0, vmax=255)
    else:
        plt.subplot(122), plt.imshow(magnitude, 'Greys')

    plt.title(name), plt.xticks([]), plt.yticks([])
    plt.show()


images = glob.glob('*.png')
for name in images:
    img = np.float32(cv.imread(name, 0))
    f = np.fft.fft2(img)
    fshift = np.fft.fftshift(f)
    showDFFT(img, fshift, 'classic furie')


def DFFTnp(img):
    f = np.fft.fft2(img)
    fshift = np.fft.fftshift(f)
    return fshift


def reverseDFFTnp(dfft):
    f_ishift = np.fft.ifftshift(dfft)
    reverse_image = np.fft.ifft2(f_ishift)
    return reverse_image


# Sobel
for name in images:
    img = np.float32(cv.imread(name, 0))
    fshift = DFFTnp(img)
    ksize = 3
    kernel = np.zeros(img.shape)
    sobel_v = np.array([[-1, -2, -1], [0, 0, 0], [1, 2, 1]])
    sobel_h = np.array([[-1, 0, 1], [-2, 0, 2], [-1, 0, 1]])
    kernel[0: ksize, 0: ksize] = sobel_h
    fkshift = DFFTnp(kernel)
    mult = np.multiply(fshift, fkshift)
    reverse_image = reverseDFFTnp(mult)
    showDFFT(img, reverse_image, 'Sobel')

# Gauss
for name in images:
    img = np.float32(cv.imread(name, 0))
    ksize = 21
    kernel = np.zeros(img.shape)
    blur = cv.getGaussianKernel(ksize, -1)
    blur = np.matmul(blur, np.transpose(blur))
    kernel[0:ksize, 0:ksize] = blur
    fkshift = DFFTnp(kernel)
    f = np.fft.fft2(img)
    fshift = np.fft.fftshift(f)
    mult = np.multiply(fshift, fkshift)
    reverse_image = reverseDFFTnp(mult)
    showDFFT(img, reverse_image, 'Gauss')
