import pygame
from objects import *
from ui import *

pygame.init()
screen = pygame.display.set_mode((1280, 720))
clock = pygame.time.Clock()
running = True

triangle = RightTriangle((20, 1200), 100, (180, 180, 180), math.radians(30))

while running:
    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            running = False

    screen.fill("black")

    pygame.draw.lines(screen, triangle.color, True, triangle.points, width=2)

    pygame.display.flip()

    clock.tick(60)

pygame.quit()